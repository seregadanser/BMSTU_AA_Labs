import matplotlib.pyplot as plt
import csv
sizes = [
500,520,540,560,
580,600,620,640,
660,680,700,720,
740,760,780,800,
820,840,860,880,
900,920,940,960,
980,1000,1020,1040,
1060,1080,1100,1120,
1140,1160,1180,1200,
1220,1240,1260,1280,
1300,1320,1340,1360,
1380,1400,1420,1440,
1460,1480,1500,1520,
1540,1560,1580,1600,
1620,1640,1660,1680,
1700,1720,1740,1760,
1780,1800,1820,1840,
1860,1880,1900,1920,
1940,1960,1980,2000,
2020,2040,2060,2080,
2100,2120,2140,2160,
2180,2200,2220,2240,
2260,2280,2300,2320,
2340,2360,2380,2400,
2420,2440,2460,2480,
2500]
X = [
2.46,2.34,2.38,2.58,2.71,2.90,3.03,3.20,
3.27,3.52,3.60,3.82,4.09,4.44,4.60,4.90,
5.07,5.35,5.54,5.90,6.01,6.39,6.60,7.06,
7.12,7.49,7.64,8.13,8.24,8.62,8.79,9.32,
9.40,9.82,9.93,10.37,10.53,11.02,11.14,11.47,
11.72,12.09,12.32,12.90,12.96,13.34,13.53,14.17,
14.34,15.06,15.29,15.97,16.49,16.81,17.16,17.68,
17.84,18.74,18.84,19.47,19.72,20.55,20.56,21.50,
21.57,22.54,22.55,23.27,23.73,24.47,24.55,25.38,
25.22,26.46,26.29,27.24,27.12,28.21,28.61,28.91,
29.82,30.00,30.99,31.54,32.08,32.56,33.27,33.38,
34.80,34.96,37.09,35.41,36.02,38.58,37.29,37.99,
39.18,39.55,41.06,41.76, 40.87]
Y = [
2.82,2.71,2.82,3.01,3.18,3.36,3.40,3.59,
3.84,4.04,4.26,4.41,4.62,4.94,5.14,5.41,
5.58,5.80,6.11,6.41,6.76,6.93,7.19,7.48,
7.72,7.97,8.25,8.54,8.92,9.14,9.39,9.70,
10.05,10.35,10.73,11.02,11.35,11.66,11.86,12.42,
12.60,12.91,13.34,13.72,14.02,14.36,14.73,15.18,
15.57,15.86,16.23,16.80,17.24,17.35,17.83,18.46,
18.50,20.39,20.66,19.96,20.35,21.04,20.90,21.29,
21.73,21.96,22.50,22.69,23.40,23.85,23.98,25.23,
25.13,25.65,25.97,27.94,27.71,26.80,27.76,28.87,
29.14,29.50,30.72,31.56,30.64,31.00,31.33,32.11,
32.12,32.91,33.13,33.92,34.33,34.12,35.46,36.08,
37.49,39.38,40.59,40.05,41.71]
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
