import matplotlib.pyplot as plt
fig1 = plt.figure(figsize=(10, 7))
plot = fig1.add_subplot()
values = [80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190, 200, 210, 220]
very_short = [1, 1, 1, 5/6, 5/6, 5/6, 4/6, 1/6, 0, 0, 0, 0, 0, 0, 0]
short = [0, 0, 0, 1/6, 1/6, 1/6, 2/6, 4/6, 4/6, 0, 0, 0, 0, 0, 0]
average = [0, 0, 0, 0, 0, 0, 0, 1/6, 2/6, 1, 3/6, 1/6, 0, 0, 0]
high = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2/6, 5/6, 1/6, 0, 0]
very_high = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2/6, 5/6, 1, 1]

plot.plot(values, very_short, label = "«Очень низкий»")
plot.plot(values, short, ":", label="«Низкий»", marker="o")
plot.plot(values, average, "--", label="«Средний»", marker="v")
plot.plot(values, high, "--", label="«Высокий»", marker="^")
plot.plot(values, very_high, "--", label="«Очень высокий»", marker="s")

plt.legend()
plt.grid()
plt.title("Графики функций принадлежности числовых значений \nпеременной термам, описывающим группы значений лингвистической переменной")
plt.ylabel("μ")
plt.xlabel("Рост, см.")

plt.show()