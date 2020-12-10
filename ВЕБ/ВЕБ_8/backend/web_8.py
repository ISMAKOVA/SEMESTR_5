import re
from string import punctuation
from nltk.corpus import stopwords
from nltk.stem.snowball import SnowballStemmer
from nltk.tokenize import word_tokenize
import pymorphy2



def read_doc(text_name):
    result = []
    path = '/Applications/MAMP/htdocs/5 семестр/ВЕБ_8/лаба_8/' + text_name + '.txt'
    string = ""
    f = open(path)
    for line in f.readlines():
        string += line
    all_docs = re.split(r'[\n]+', string)
    sentence = re.split(r'\.', string)
    for par in all_docs:
        if par != "":
            result.append(par)
    # print(result)
    return result, sentence


def preprocessing_data(text):
    stop_words = set(stopwords.words('russian') + list(punctuation)) #список стоп-слов
    stemmer = SnowballStemmer("russian")
    morph = pymorphy2.MorphAnalyzer()
    text = text.lower() #приведение слов к строчным
    text = re.sub('[^а-яА-Я]', ' ', text, flags=re.MULTILINE)#удаляем знаки пунктуации
    tokens = word_tokenize(text) #разделяем слова на отдельные токены
    text = [word for word in tokens if word not in stop_words] #удаляем стоп-слова
    # text = [stemmer.stem(word) for word in text] #производим стемминг
    text = [morph.parse(word)[0].normal_form for word in text]
    text = ' '.join(text)
    return text


def create_dict(text):
    text_dict = {}
    join_text = ' '.join(text)
    for word in join_text.split():
        if word not in text_dict:
            text_dict[word] = join_text.count(word)*sum([1.0 for par in text if word in par])/(len(text)*len(join_text.split()))
    return text_dict, len(text), len(join_text.split())


def key_words(text_dict, text):
    result = []
    words = ' '.join(text).split()
    for i in range(len(words)-1):
        if (text_dict[words[i]][1] == "ГОС" or text_dict[words[i]][1] == "ВОС") and text_dict[words[i+1]][1] == "ГОС" or text_dict[words[i+1]][1] == "ВОС":
            result.append(words[i] +" "+ words[i+1])
    for i in range(len(words)-2):
        if (text_dict[words[i]][1] == "ГОС" or text_dict[words[i]][1] == "ВОС") and text_dict[words[i+1]][1] == "ГОС" or text_dict[words[i+1]][1] == "ВОС" and text_dict[words[i+2]][1] == "ГОС" or text_dict[words[i+2]][1] == "ВОС":
            result.append(words[i] +" "+ words[i+1] + " "+ words[i+2])
    print(result)
    return result


def key_sentences(text_dict, sentences):
    result = {}
    for s in sentences:
        for ws in preprocessing_data(s).split():
            count = 0
            for i in text_dict.keys():
                if i == ws and i != "Н":
                    count += 1
            result[count/len(set(preprocessing_data(s).split()))] = s
    # print(result)
    return result


if __name__ == '__main__':
    text, sentences = read_doc("text_3")
    text = [preprocessing_data(i) for i in text]
    sentences = [preprocessing_data(i) for i in sentences]
    text_dict, n, N = create_dict(text)
    for word, val in text_dict.items():
        if val>= 9/(n*N) and val <1:
            text_dict[word] = [val, "ГОС"]
        elif val>= ((1+n/4)**2)/(n*N) and val <9/(n*N):
            text_dict[word] = [val, "ВОС"]
        else:
            text_dict[word] = [val, "Н"]
    print("------------------------------")
    print("1.	Список ключевых слов с маркировкой ГОС или ВОС и величиной K")
    for i, v in text_dict.items():
        print(i, v)
    print("------------------------------")
    print("2.	Список ключевых понятий.")
    key_words(text_dict, text)
    print("------------------------------")
    print("3.	Реферат в виде трех предложений с указанием индекса релевантности. ")
    key_s = key_sentences(text_dict, sentences)
    list_keys = list(key_s.keys())
    list_keys.sort(reverse=True)
    for i in list_keys[:4]:
        print(i, ':', key_s[i])
