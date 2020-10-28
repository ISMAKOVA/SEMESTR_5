from flask import Flask, request, jsonify, render_template
import pymorphy2
import re
import csv
from collections import Counter
import math

app = Flask(__name__)


@app.route('/')
def index():
    return render_template('index.html')


@app.route('/data', methods=['GET', 'POST'])
def data():
    file = request.form.get('file')
    my_filter = request.form.get('filter')
    path = '/Applications/MAMP/htdocs/SEMESTR_5/ВЕБ/ВЕБ_3/лаба_3/' + file
    docs = read_file(path)
    my_docs, my_dict = clear_text(docs)
    boolean, tf, tf_idf = vsm(my_docs, my_dict)
    table = []
    if int(my_filter) == 0:
        table = boolean
    elif int(my_filter) == 1:
        table = tf
    elif int(my_filter) == 2:
        table = tf_idf
    write_csv(table)
    result = list(table.items())
    result.sort(key=lambda i: i[1][0])
    result.reverse()
    return jsonify(result)


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
                b.append(0)
                c.append(0)

        boolean[my_dict[i]] = a
        tf[my_dict[i]] = b
        tf_idf[my_dict[i]] = c
    return boolean, tf, tf_idf


def create_dict(my_dict, table):
    res_dict = {}
    for i in range(len(table)):
        tmp = {}
        for word in table[i]:
            tmp = dict(zip(my_dict, table[i]))
        res_dict[i] = tmp
    return res_dict


def write_csv(info):
    with open('vsm.csv', 'w', encoding='utf-8') as file:
        a_pen = csv.writer(file)
        for i, doc in info.items():
            str_r = [i]+doc
            a_pen.writerow(str_r)

#для проверки в консоли
def check():
    path = '/Applications/MAMP/htdocs/SEMESTR_5/ВЕБ/ВЕБ_3/лаба_3/dataset.txt'
    docs = read_file(path)
    my_docs, my_dict = clear_text(docs)
    boolean, tf, tf_idf = vsm(my_docs, my_dict)

    write_csv(tf_idf)

check()