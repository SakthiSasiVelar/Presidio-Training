# class

class Person:
    def __init__(self, name, age):
        self.name = name
        self.age = age
    
    def introduce(self):
        return f"Hello, my name is {self.name} and I'm {self.age} years old."

# creating an instance of the class

person1 = Person("John Doe", 30)
print(person1.introduce())

#inheritance

class Employee(Person):
    def __init__(self, name, age, job_title):
        super().__init__(name, age)
        self.job_title = job_title

    def introduce(self):
        return f"Hello, my name is {self.name}, I'm {self.age} years old and I work as {self.job_title}."
    
person2 = Employee("John Doe",20,"SDE")
print(person2.introduce())

# polymorphism

class Vehicle:
  def __init__(self, brand, model):
    self.brand = brand
    self.model = model

  def move(self):
    print("Move!")

class Car(Vehicle):
  pass

class Boat(Vehicle):
  def move(self):
    print("Sail!")

class Plane(Vehicle):
  def move(self):
    print("Fly!")

car1 = Car("Ford", "Mustang") 
boat1 = Boat("Ibiza", "Touring 20") 
plane1 = Plane("Boeing", "747") 

for x in (car1, boat1, plane1):
  print(x.brand)
  print(x.model)
  x.move()

#modules 
import samplemodule 

samplemodule.greeting("John")

from samplemodule import moduleVariable 

print(moduleVariable)

#find all function in modules
print(dir(samplemodule))

#try catch exceptions

try:
    print(10 / 0)
except ZeroDivisionError:
    print("Error: Division by zero")
except Exception as e:
   print(e)
finally:
    print("Finally block executed")


try :
   raise Exception('user defined exception')
except Exception as e:
   print('An error occurred:',e)