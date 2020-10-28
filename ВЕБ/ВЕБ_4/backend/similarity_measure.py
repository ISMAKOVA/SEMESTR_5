import vsm
import math
import operator

query = [
    "знаменитый ученый Стивен Хокинг рассказал в интервью ТАСС о будущем человечества на Марсе. По мнению физика-теоретика, колонизация Марса состоится в ближайшие 100 лет.Внимание NASA и других мировых космических агентств сосредоточено на Марсе. Это ближайшая похожая на Землю планета, с почвой и атмосферой. И хотя колонизировать Луну было бы проще — она находится всего лишь в трех днях [полета от Земли], освоение Марса представляется более интересной задачей и потребовало бы создания действительно автономной колонии», — уверен ученый."]
my_docs_q, my_dict_q = vsm.clear_text(query)
tf_idf_q = vsm.compute_tf_idf1(my_docs_q, my_dict_q)

path = '/Applications/MAMP/htdocs/SEMESTR_5/ВЕБ/ВЕБ_3/лаба_3/dataset.txt'
docs = vsm.read_file(path)
my_docs_d, my_dict_d = vsm.clear_text(docs)
tf_idf_d = vsm.compute_tf_idf1(my_docs_d, my_dict_d)


def cosine(tf_idf_1, tf_idf_2):
    def multiple(v1, v2):
        return sum(map(operator.mul, v1, v2))

    def cos(v1, v2):
        num = multiple(v1, v2)
        den = math.sqrt(multiple(v1, v1)) * math.sqrt(multiple(v2, v2))
        return num / den

    vec1 = [i[0] for i in tf_idf_1.values()]
    vec2 = [i for i in tf_idf_2.values()]
    res = []
    for vec in tf_idf_2.values():
        for i in range(len(vec)):
            cur = [z[i] for z in vec2]
            res.append(cos(vec1, cur))
        break
    return res


print(cosine(tf_idf_q, tf_idf_d))


def jaccard(tf_idf_1, tf_idf_2):

    def sim_jaccard(v1, v2):
        res_min = 0
        res_max = 0
        for i in range(len(v1)):
            res_min += min(v1[i], v2[i])
            res_max += max(v1[i], v2[i])
        return res_min / res_max

    vec1 = [i[0] for i in tf_idf_1.values()]
    vec2 = [i for i in tf_idf_2.values()]
    res = []
    for vec in tf_idf_2.values():
        for i in range(len(vec)):
            cur = [z[i] for z in vec2]
            res.append(sim_jaccard(vec1, cur))
        break
    return res


print(jaccard(tf_idf_q, tf_idf_d))


def dice(tf_idf_1, tf_idf_2):
    def sim_dice(v1, v2):
        res_sum = sum(map(operator.add, v1, v2))
        res_min = 0
        for i in range(len(v1)):
            res_min += min(v1[i], v2[i])
        return 2 * res_min / res_sum

    vec1 = [i[0] for i in tf_idf_1.values()]
    vec2 = [i for i in tf_idf_2.values()]
    res = []
    for vec in tf_idf_2.values():
        for i in range(len(vec)):
            cur = [z[i] for z in vec2]
            res.append(sim_dice(vec1, cur))
        break
    return res


print(dice(tf_idf_q, tf_idf_d))