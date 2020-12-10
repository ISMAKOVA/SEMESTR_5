from flask import Flask, request, jsonify, render_template
from flask_cors import CORS
import vsm
import csv_do
import naiv_bayes
import math

app = Flask(__name__)
cors = CORS(app)


@app.route('/learn', methods=['GET', 'POST'])
def learn():
    class_number = request.form['class']
    text = request.form['text']
    pwc = naiv_bayes.add_prob(text, class_number)
    csv_do.write_pwc(pwc)
    return jsonify("ok")


@app.route('/class', methods=['GET', 'POST'])
def my_class():
    test_doc = request.form['text']
    clear_test_doc, test_dict = vsm.clear_one_text(test_doc)
    pwc = csv_do.read_pwc()
    p_w_c_dict = {}
    n1_list = []
    n2_list = []
    n3_list = []
    for token, i in pwc.items():
        p_w_c_dict[token] = i[3:6]
        n1_list.append(i[7])
        n2_list.append(i[8])
        n3_list.append(i[9])
    n1 = int(max(n1_list))
    n2 = int(max(n2_list))
    n3 = int(max(n3_list))
    sum = n1 + n2 + n3
    print(p_w_c_dict)
    cl1, cl2, cl3 = naiv_bayes.prob_doc(clear_test_doc, p_w_c_dict, n1 / sum, n2 / sum, n3 / sum)
    my_max = max(cl1, cl2, cl3)
    print(my_max)
    res = ""
    if my_max == cl1:
        res = 'Класс 1'
    elif my_max == cl2:
        res = 'Класс 2'
    else:
        res = 'Класс 3'
    return jsonify([{'Класс 1': cl1, 'Класс 2': cl2, 'Класс 3': cl3}], res)


@app.route('/existFile', methods=['GET', 'POST'])
def index():
    file = request.files['file'].filename
    docs = naiv_bayes.get_docs('/Applications/MAMP/htdocs/5 семестр/ВЕБ_5/лаба_5/train/')
    my_docs, V = vsm.clear_text(docs)
    p_w_c, p_w_c_dict = naiv_bayes.probability(my_docs, V)

    csv_do.write_str(p_w_c, "pwc.csv")

    path = "/Applications/MAMP/htdocs/5 семестр/ВЕБ_5/лаба_5/test/" + file
    test_doc = vsm.read_file(path)
    clear_test_doc, test_dict = vsm.clear_one_text(test_doc)
    cl1, cl2, cl3 = naiv_bayes.prob_doc(clear_test_doc, p_w_c_dict)
    my_max = max(cl1, cl2, cl3)
    res = ""
    if my_max == cl1:
        res = 'Класс 1'
    elif my_max == cl2:
        res = 'Класс 2'
    else:
        res = 'Класс 3'
    return jsonify([{'Класс 1': cl1, 'Класс 2': cl2, 'Класс 3': cl3}], res)


if __name__ == '__main__':
    app.debug = True
    app.run()
