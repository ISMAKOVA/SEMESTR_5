import pymorphy2
import re
from collections import Counter
import math
from heapq import nlargest

def read_file(obj_file):
    string = ''
    result = []
    f = open(obj_file)
    for line in f.readlines():
        string += line
    all_docs = re.split(r'Документ\s+№\s*\d+[*]+', string)
    for doc in all_docs:
        result += [doc]
    return result


def clear_text(docs):
    my_docs = []
    my_dict = []
    for doc in docs:
        morph = pymorphy2.MorphAnalyzer()
        t = re.split(r'\W+', doc.lower())
        r = re.compile("[а-яА-Яa-zA-Z]+")
        token_list = [w for w in filter(r.match, t)]
        clear_token_list = []
        for token in token_list:
            clear_token_list.append(morph.parse(token)[0].normal_form)
        my_docs.append(clear_token_list)
        for token in clear_token_list:
            if token not in my_dict:
                my_dict.append(token)
    return my_docs, my_dict


def vsm1(my_docs, my_dict):
    boolean = [[0] * len(my_dict) for i in range(len(my_docs))]
    tf1 = [[0] * len(my_dict) for i in range(len(my_docs))]
    tf2 = [[0] * len(my_dict) for i in range(len(my_docs))]
    tf_idf = [[0] * len(my_dict) for i in range(len(my_docs))]
    boolean2 = {}
    tf = {}
    tf_idf1 = {}

    for i in range(len(my_docs)):
        for j in range(len(my_dict)):
            if my_dict[j] in my_docs[i]:
                boolean[i][j] = 1
                tf1[i][j] = my_docs[i].count(my_dict[j])
                tf2[i][j] = my_docs[i].count(my_dict[j])/len(my_docs[i])

    for i in range(len(my_docs)):
        for j in range(len(my_dict)):
            tf_idf[i][j] = tf2[i][j]*math.log2(len(my_docs[i])/sum([1.0 for z in my_docs if my_dict[j] in z]))

    for i in range(len(my_dict)):
        a = []
        b = []
        c = []
        for j in range(len(my_docs)):
            if my_dict[i] in my_docs[j]:
                a.append(1)
                b.append(my_docs[j].count(my_dict[i]))
                c.append(tf2[j][i] * math.log2(len(my_docs[j]) / sum([1.0 for z in my_docs if my_dict[i] in z])))
            else:
                a.append(0)

        boolean2[my_dict[i]] = a
        tf[my_dict[i]] = b
        tf_idf1[my_dict[i]] = c
    return boolean, tf1, tf_idf

def vsm(my_docs, my_dict):
    boolean = {}
    tf = {}
    tf_idf = {}
    tf2 = [[0] * len(my_dict) for i in range(len(my_docs))]

    for i in range(len(my_docs)):
        for j in range(len(my_dict)):
            if my_dict[j] in my_docs[i]:
                tf2[i][j] = my_docs[i].count(my_dict[j]) / len(my_docs[i])

    for i in range(len(my_dict)):
        a = [], b = [], c = []
        for j in range(len(my_docs)):
            if my_dict[i] in my_docs[j]:
                a.append(1)
                b.append(my_docs[j].count(my_dict[i]))
                c.append(tf2[j][i] * math.log2(len(my_docs[j]) / sum([1.0 for z in my_docs if my_dict[i] in z])))
            else:
                a.append(0)

        boolean[my_dict[i]] = a
        tf[my_dict[i]] = b
        tf_idf[my_dict[i]] = c


def create_dict(my_dict, table):
    res_dict = []
    for i in range(len(table)):
        tmp = {}
        for word in table[i]:
            tmp = dict(zip(my_dict, table[i]))
        res_dict.append(tmp)

    return res_dict


def check():
    path = '/Applications/MAMP/htdocs/5 семестр/ВЕБ_3/лаба_3/dataset.txt'
    docs = read_file(path)
    my_docs, my_dict = clear_text(docs)
    table1, table2, table3 = vsm(my_docs, my_dict)
    # res = nlargest(30, t, key=lambda x: x[1])
    res = create_dict(my_dict, table1)
check()