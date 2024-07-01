#multiline string

a = """This is a multiline string.
It spans multiple lines.
This allows for better readability and maintainability.
"""

print(a)

# loop string

for char in a:
    print(char)

# getting string through index number

print(a[10])

# check string

str = 'hello world'
print('hello' in str)

# length of string

print(len(str))

#slice string (start,stop,increment)

print(str[0:5:2])

#negative indexing

print(str[-5:-2])

# strip - remove whitespace in beginning and ending

str = '   hello world   '
print(str.strip())

#f-string

name = 'John'
age = 30
print(f'My name is {name} and I am {age} years old.')



#function 

def greet(name):
    print(f'Hello, {name}!')

greet('John')

# arbitary function

def greet(*names):
    for name in names:
        print(f'Hello, {name}!')

greet('John', 'Alice', 'Bob')


# keyword function

def greet(**kwargs):
    for name, age in kwargs.items():
        print(f'Hello, {name} (age: {age})!')

greet(John=30, Alice=25, Bob=35)

# default parameter

def greet(name='World', greeting='Hello'):
    print(f'{greeting}, {name}!')

greet()
greet('John')