import json
from human import Human
from utils import check_request, get_interval, search

with open('/Users/p.kalashkov/Desktop/fifthTerm/bmstu-aa/lab06/src/data/humans.json', 'r') as file:
    data = file.read().replace('\n', '')
true_data = []
data = json.loads(data)
for d in data:
    r = d.get('result')
    h = Human(r.get('name'), r.get('gender'), r.get('country'), r.get('skill'), r.get('height'))
    item = {r.get('height'): h}
    true_data.append(h)

data = true_data


def main():
    request = input("Введите запрос: ")
    term = check_request(request)
    if not term :
        return
    interval, is_not = get_interval(term)
    result = search(data, interval, is_not)
    for human in result:
        print(human)

main()
