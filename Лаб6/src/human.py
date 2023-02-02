class Human:
    def __init__(self, name, gender, country, skill, height) -> None:
        self.name = name
        self.gender = gender
        self.country = country
        self.skill = skill
        self.height = height

    def __str__(self):
        return f'{self.height}, {self.name}, {self.gender}, {self.country}, {self.skill}'

