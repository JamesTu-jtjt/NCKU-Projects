# -*- coding: utf-8 -*-
"""
Created on Sat Jun 12 18:37:27 2021

@author: user
"""

from kivy.app import App
from kivy.lang import Builder
from kivy.uix.screenmanager import ScreenManager, Screen
from kivy.properties import ObjectProperty
from kivy.uix.popup import Popup
from kivy.uix.label import Label
from kivy.core.window import Window
from database import DataBase


class AddDataPage(Screen):
    full_name = ObjectProperty(None)
    school = ObjectProperty(None)
    department = ObjectProperty(None)
    email = ObjectProperty(None)
    skills = ObjectProperty(None)
    habits = ObjectProperty(None)

    def submit(self):
        if self.full_name.text != "" and self.school.text != "" and self.department.text != "" and \
                self.email.text != "" and self.email.text.count("@") == 1 and self.email.text.count(".") > 0:
            db.add_user(self.email.text, self.full_name.text, self.school.text, self.department.text,
                            self.skills.text, self.habits.text)
            self.reset()
            PM.current = "search"
        else:
            invalid_info()

    def search_data(self):
        self.reset()
        PM.current = "search"

    def reset(self):
        self.full_name.text = ""
        self.school.text = ""
        self.department.text = ""
        self.email.text = ""
        self.skills.text = ""
        self.habits.text = ""
    
    def close_btn(self):
        close_page()


class SearchPage(Screen):
    sk = ObjectProperty(None)

    def search_btn(self):
        if db.check_sk(self.sk.text):
            ContactPage.skill = self.sk.text
            self.reset()
            PM.current = "contacts"
        else:
            invalid_skill()
            
    def create_btn(self):
        self.reset()
        PM.current = "add_data"
        
    def reset(self):
        self.sk.text = ""
    
    def close_btn(self):
        close_page()


class ContactPage(Screen):
    email = ObjectProperty(None)
    results = ObjectProperty(None)
    skill = ""
    
    def on_enter(self, *args):
        r = "Results for " + self.skill + ': \n'
        contacts = db.skill_search(self.skill)
        tmp = 0
        for i in contacts: 
            r += i + ", "
            tmp += 1
            if tmp == 3:
                r += '\n'
                tmp = 0
        self.results.text = r
    
    def search_btn(self):
        if db.check(self.email.text):
            HomePage.current = self.email.text
            self.reset()
            PM.current = "home"
        else:
            invalid_search()
            
    def reset(self):
        self.email.text = ""
    
    def close_btn(self):
        close_page()


class HomePage(Screen):
    n = ObjectProperty(None)
    sd = ObjectProperty(None)
    sk = ObjectProperty(None)
    ha = ObjectProperty(None)
    e = ObjectProperty(None)
    t = ObjectProperty(None)
    current = ""

    def on_enter(self, *args):
        full_name, school, department, skills, habits, time = db.get_user(self.current)
        self.n.text = "Name: " + full_name
        self.e.text = "Email: " + self.current
        self.sd.text = "From: " + school + " " + department
        self.sk.text = "Skills: " + str(skills.split("/"))
        self.ha.text = "Habits: " + str(habits.split("/"))
        self.t.text = "Data added or modified at: " + time 
        
    def close_btn(self):
        close_page()

    @staticmethod
    def notifications():
        pop = Popup(title='Notifications', content=Label(text='Dear user, \n'
                                                              '    Hi there, and welcome to our page!'), 
                    size_hint=(None, None), size=(600, 200))
        pop.open()
    


class PageManager(ScreenManager):
    pass


kv = Builder.load_file("userinterface.kv")
db = DataBase("userinfo.txt")

PM = PageManager()


def invalid_search():
    pop = Popup(title='Invalid Search', content=Label(text='Email not found.'),
                size_hint=(None, None), size=(400, 400))
    pop.open()

def invalid_skill():
    pop = Popup(title='Invalid Search', content=Label(text='Skill not found.'),
                size_hint=(None, None), size=(400, 400))
    pop.open()

def invalid_info():
    pop = Popup(title='Invalid Information', content=Label(text='Please fill in valid information.'),
                size_hint=(None, None), size=(400, 400))
    pop.open()


screens = [SearchPage(name="search"), AddDataPage(name="add_data"), ContactPage(name = "contacts"), HomePage(name="home")]
for screen in screens:
    PM.add_widget(screen)

PM.current = "search"

def close_page():
    Window.close()
    App.get_running_app().stop()


class UserInterface(App):
    def build(self):
        return PM


if __name__ == "__main__":
    UserInterface().run()
