import matplotlib.pyplot as plt
import csv

sizes = [10000, 12500, 15000, 17500, 20000]
X = [57, 112, 267, 342, 400 ]
Y = [ 77, 160, 300, 421, 458]



 
fig1 = plt.figure(figsize=(10, 7))
plot = fig1.add_subplot()
plot.plot(sizes, X, label = "параллельная конвейерная обработка")
#plot.plot(sizes, Z, label="алгоритм с барицентрическими координатами")
plot.plot(sizes, Y, label="последовательная обработка")
#plot.plot(sizes, A, label="Дамерау-Левенштейна рекурсивный")
plt.legend()
plt.grid()
plt.title("Временные характеристики алгоритмов конвейерной обработки")
plt.ylabel("Затраченное время (c)")
plt.xlabel("размер входных строк в символах")
plt.show()
