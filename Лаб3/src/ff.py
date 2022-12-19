import matplotlib.pyplot as plt
import csv
sizes = [10000, 12500, 15000, 17500, 20000, 22500, 25000]
X = [57.72,96.65 ,143.39,207.20,276.24 , 390.22,  455.11 ]
Y = [65.34, 119.91, 195.14,238.38 ,  334.03 , 465.59,  524.06 ]
#Z =[]

 
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
