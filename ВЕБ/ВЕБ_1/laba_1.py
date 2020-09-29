import requests
import csv
from bs4 import BeautifulSoup
headers = requests.utils.default_headers()
headers.update({ 'User-Agent': 'Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:52.0) Gecko/20100101 Firefox/69.0'})
base_url = 'https://www.e-katalog.ru/k265.htm'

def parse(header_html, base_url):
    urls =[]
    info=[]
    req = requests.get(base_url, header_html)
    soup = BeautifulSoup(req.text, 'html.parser')
    goods = soup.find_all("div", class_="top_goods")
    for camera in goods:
        href = camera.find('a').get('href')
        urls.append(href)
    for url in urls:
        cur_url = base_url.split('/')[0]+base_url.split('/')[1]+'//'+base_url.split('/')[2]+url
        req2 = requests.get(cur_url, header_html)
        soup2 = BeautifulSoup(req2.text, 'html.parser')
        category = soup2.find('a', class_='path_lnk').text
        name = soup2.find('div', class_='op1-tt').text
        desc = soup2.find('div',class_='conf-desc-ai-title').text
        info.append({
            'url': cur_url,
            'category': category,
            'name': name,
            'desc': desc
        })
    return info

def write_csv(info):
    with open('parsed_info.csv', 'w', encoding='utf-8') as file:
        a_pen = csv.writer(file)
        a_pen.writerow(('Адрес', 'Категория', 'Название', 'Описание'))
        for i in info:
            a_pen.writerow((i['url'], i['category'], i['name'], i['desc']))


info_list = parse(headers, base_url)
write_csv(info_list)
