import datetime


class DataBase:
    def __init__(self, filename):
        self.filename = filename
        self.info = None
        self.file = None
        self.load()

    def load(self):
        self.file = open(self.filename, "r")
        self.info = {}

        for line in self.file:
            email, full_name, school, department, skills, habits, time = line.strip().split(";") 
            self.info[email] = (full_name, school, department, skills, habits, time)

        self.file.close()

    def get_user(self, email):
        if email in self.info:
            return self.info[email]
        else:
            return -1
        
    def skill_search(self, skill):
        contacts = []
        for i in self.info.keys():
            skills = [j.lower() for j in self.info[i][3].split('/')]
            for s in skills:
                if skill.lower() in s:
                    contacts.append(i)
        if len(contacts) == 0:
            return -1
        return contacts

    def add_user(self, email, full_name, school, department, skills, habits):
        self.info[email.strip()] = (full_name.strip(), school.strip(),
                                    department.strip(), skills.strip(), habits.strip(), DataBase.get_time())
        self.save()

    def check(self, email):
        if self.get_user(email) != -1:
            return True
        else:
            return False
        
    def check_sk(self, skill):
        if self.skill_search(skill) != -1:
            return True
        else:
            return False

    def save(self):
        with open(self.filename, "w") as f:
            for user in self.info:
                f.write(user + ";" + self.info[user][0] + ";" + self.info[user][1] + ";" + self.info[user][2] + ";" + 
                        self.info[user][3] + ";" + self.info[user][4] + ";" + self.info[user][5] + "\n")

    @staticmethod
    def get_time():
        return str(datetime.datetime.now()).split(" ")[0]
