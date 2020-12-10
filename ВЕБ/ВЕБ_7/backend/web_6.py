import vsm
import csv
import math
from flask import Flask, request, jsonify, render_template
from flask_cors import CORS

app = Flask(__name__)
cors = CORS(app)


def get_docs(file_csv):
    text = {}
    with open(file_csv) as f:
        reader = csv.DictReader(f, delimiter=';')
        for line in reader:
            if line['class'] in text:
                text[line['class']].append([line["\ufefftitle"], line['keywords'], line['annotation']])
            else:
                text[line['class']] = [line["\ufefftitle"], line['keywords'], line['annotation']]
    docs = []
    for doc in text.values():
        str = ""
        for i in doc:
            str += ''.join(i)
        docs.append(str)
    return docs


def get_test_docs(file_csv):
    text = []
    with open(file_csv) as f:
        reader = csv.DictReader(f, delimiter=';')
        for line in reader:
            text.append(''.join([line["\ufefftitle"], line['keywords'], line['annotation']]))
    return text


def prob_doc(test_doc, p_w_c_dict):
    cl1 = math.log2(1 / 4)
    cl2 = math.log2(1 / 4)
    cl3 = math.log2(1 / 4)
    cl4 = math.log2(1 / 4)
    for i in test_doc:
        if i in p_w_c_dict:
            cl1 += math.log2(float(p_w_c_dict[i][0]))
            cl2 += math.log2(float(p_w_c_dict[i][1]))
            cl3 += math.log2(float(p_w_c_dict[i][2]))
            cl4 += math.log2(float(p_w_c_dict[i][3]))
    return {1: cl1,2: cl2,3: cl3,4: cl4}


def probability(my_docs, V):
    count = [len(words) for words in my_docs]
    tf = vsm.compute_tf(my_docs, V)
    result = []
    pwc_dict = {}
    for token in V:
        p = []
        p.append(token)
        for i in tf[token]:
            p.append(i)
        for i in range(len(tf[token])):
            p.append((tf[token][i]+1)/(count[i]+len(V)))
        pwc_dict[token] = p[5:]
        result.append(p)
    return result, pwc_dict


docs = get_docs("train.csv")
my_docs, V = vsm.clear_text(docs)
p_w_c, p_w_c_dict = probability(my_docs, V)

#test_docs = get_test_docs("test.csv")
#clear_test_doc, test_dict = vsm.clear_text(test_docs)


def get_key(d, value):
    for k, v in d.items():
        if v == value:
            return k


def read_statistics():
    text = {}
    with open("statistics.csv") as f:
        reader = csv.DictReader(f, delimiter=',')
        for line in reader:
            text[line['number']] = [line["TP"], line['FP'], line['FN']]
    return text


def write_statistics(statistics):
    with open("statistics.csv", 'w', encoding='utf-8') as file:
        a_pen = csv.writer(file)
        columns = ['number','TP','FP','FN']
        a_pen.writerow(columns)
        for token, i in statistics.items():
            str_r = [token] + i
            a_pen.writerow(str_r)


@app.route('/findRub', methods=['GET', 'POST'])
def index():
    class_number = request.form['class']
    text = request.form['text']
    print(class_number, text)
    # class_number = 3
    # text = "Formulating LLE using alignment technique;lle; ltsa; nonlinear dimensionality reduction; manifold learning;;LLE is a well-known method to nonlinear dimensionality reduction. In this short paper, we present an alternative way to formulate LLE. The alignment technique is exploited to align the local coordinates on the local patches of manifolds to be the global ones. The efficient computation of embedding coordinates of LLE automatically appears in the proposed framework."
    clear_test_doc, test_dict = vsm.clear_one_text(text)
    cl = prob_doc(clear_test_doc, p_w_c_dict)
    sort = sorted(cl.values(), reverse=True)
    res = {}
    for i in sort:
        res[get_key(cl, i)] = i
    cl_number = get_key(cl, sort[0])
    statistics = read_statistics()

    if int(cl_number) == int(class_number):
        statistics[str(cl_number)][0] = int(statistics[str(cl_number)][0]) + 1
    else:
        statistics[str(cl_number)][1] = int(statistics[str(cl_number)][1]) + 1
        statistics[str(class_number)][2] = int(statistics[str(class_number)][2]) + 1

    write_statistics(statistics)
    result = []
    for i, j in res.items():
        if i == 1:
            result.append({"№": i, "Рубрика": 'Classification problems', "Величина вероятности": j})
        elif i == 2:
            result.append({"№": i, "Рубрика": 'Pattern recognition', "Величина вероятности": j})
        elif i == 3:
            result.append({"№": i, "Рубрика": 'Biometrics investigations', "Величина вероятности": j})
        elif i == 4:
            result.append({"№": i, "Рубрика": 'Image processing', "Величина вероятности": j})
    print([result])
    return jsonify(result)


@app.route('/add', methods=['GET', 'POST'])
def add():
    class_number = request.form['class']
    text = request.form['text']
    t = []
    with open("added_articles.csv") as f:
        reader = csv.DictReader(f, delimiter=',')
        for line in reader:
            t.append([line['number'], line['text']])
    t.append([class_number,text])
    with open("added_articles.csv", 'w', encoding='utf-8') as file:
        a_pen = csv.writer(file)
        columns = ['number','text']
        a_pen.writerow(columns)
        for i in t:
            a_pen.writerow(i)
    return jsonify("ok")


@app.route('/articles', methods=['GET', 'POST'])
def get_articles():
    t = []
    with open("added_articles.csv") as f:
        reader = csv.DictReader(f, delimiter=',')
        for line in reader:
            t.append([line['number'], line['text']])
    return jsonify(t)


@app.route('/statistics', methods=['GET', 'POST'])
def get_statistics():
    t = {}
    with open("statistics.csv") as f:
        reader = csv.DictReader(f, delimiter=',')
        for line in reader:
            t[line['number']] = [line['TP'], line['FP'], line['FN']]
    res = []
    for n, i in t.items():
        if int(i[0]) != 0:
            p = int(i[0]) / (int(i[0]) * int(i[1]))
            r = int(i[0]) / (int(i[0]) * int(i[2]))
            f1 = 2 * p * r / (p + r)
            res.append({'№': n, 'P': p, 'R': r, 'F1': f1})
        else:
            res.append({'№': 0, 'P': 0, 'R': 0, 'F1': 0})
    return jsonify(res)



if __name__ == '__main__':
    # index()
    app.debug = True
    app.run()

