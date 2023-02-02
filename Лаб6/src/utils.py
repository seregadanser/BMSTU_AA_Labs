from constants import *

def check_request(request):
    request = request.lower()
    result = NOT_FOUND
    if "время от дома до вуза" not in request and\
        "время в дороге" not in request and\
        "доехать от дома до вуза" not in request:
        print("В запросе должна идти речь о людях")
    elif "время" not in request:
        print("В запросе должно идти речь о человеческом росте")
    elif "не очень долго" in request:
        result = NOT_VERY_SHORT
    elif "не долго" in request:
        result = NOT_SHORT
    elif "не нормально" in request:
        result = NOT_AVERAGE
    elif "не долго" in request:
        result = NOT_TALL
    elif "не очень долго" in request:
        result = NOT_VERY_TALL
    elif "очень долго" in request:
        result = VERY_SHORT
    elif "близко" in request:
        result = SHORT
    elif "нормально" in request:
        result = AVERAGE
    elif "долго" in request:
        result = TALL
    elif "очень долго" in request:
        result = VERY_TALL
    else:
        print("Речь должна идти о каком-то из термов!")
    return result

def get_interval(term):
    is_not = False
    interval = []
    if term > 5:
        is_not = True
    term = term % 5
    if term == VERY_SHORT:
        interval = [80, 143]
    elif term == SHORT:
        interval = [144, 162]
    elif term == AVERAGE:
        interval = [163, 182]
    elif term == TALL:
        interval = [183, 194]
    else:
        interval = [195, 220]
    return interval, is_not

def search(data, interval, is_not):
    result = []
    start = interval[0]
    end = interval[1]
    for human in data:
        in_interval = False
        if human.height >= start and human.height <= end:
            in_interval = True
        if is_not != in_interval:
            result.append(human)
    return result