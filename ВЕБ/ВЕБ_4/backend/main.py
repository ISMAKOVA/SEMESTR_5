from flask import Flask, request, jsonify, render_template
from flask_cors import CORS
import vsm
import similarity_measure

app = Flask(__name__)
cors = CORS(app)


@app.route('/', methods=['GET', 'POST'])
def index():
    file = request.files['file'].filename
    #my_filter = request.form['filter']
    query = [request.form['query']]
    path = '/Applications/MAMP/htdocs/SEMESTR_5/ВЕБ/ВЕБ_3/лаба_3/'+file
    docs = vsm.read_file(path)
    my_docs_q, my_dict_q = vsm.clear_text(query)
    my_docs_d, my_dict_d = vsm.clear_text(docs)

    tf_idf_q = vsm.compute_tf_idf1(my_docs_q, my_dict_q)
    tf_idf_d = vsm.compute_tf_idf1(my_docs_d, my_dict_d)
    cosine = similarity_measure.cosine(tf_idf_q, tf_idf_d)
    jaccard = similarity_measure.jaccard(tf_idf_q, tf_idf_d)
    dice = similarity_measure.dice(tf_idf_q, tf_idf_d)
    print(cosine)
    result = []
    for i in range(len(cosine)):
        result.append({
            'doc': i + 1,
            'cosine': cosine[i],
            'jaccard': jaccard[i],
            'dice': dice[i]
        })
    print(result)
    # boolean, tf, tf_idf = vsm.vsm(my_docs_d, my_dict_d)
    # table = []
    # if int(my_filter) == 0:
    #     table = boolean
    # elif int(my_filter) == 1:
    #     table = tf
    # elif int(my_filter) == 2:
    #     table = tf_idf
    # result = list(table.items())
    # result.sort(key=lambda i: i[1][0])
    # result.reverse()
    return jsonify(result)


if __name__ == '__main__':
    app.debug = True
    app.run()