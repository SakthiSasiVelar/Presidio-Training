from datetime import datetime

# Print hello world

print('hello world')

# Take a name and print greet

name = input('Enter your name : ')
print('Welcome, ' + name)

# Take name and gender print greet with salutation

name = input('Enter your name : ')
gender = input('Enter your gender : ')

if gender.lower() == 'male':
    print('Hello Mr. ' + name)
elif gender.lower() == 'female':
    print('Hello Mrs. ' + name)

# Take name, age, date of birth and phone print details in proper format

name = input('Enter your name : ')
age = int(input('Enter your age : '))
dob = input('Enter your date of birth (d/m/y) : ')
phone = input('Enter your phone number : ')

print(f' Name : {name}\n Age : {age}\n Date of birth : {dob}\n Phone number : {phone}')

#  Add validation the entered  name, age, date of birth and phone print details in proper format

def findAgeByDob(dob) :
    dob = datetime.strptime(dob, '%d-%m-%Y')
    today = datetime.today()
    age = today.year - dob.year - ((today.month, today.day) < (dob.month, dob.day))
    return age

if len(phone) != 10 :
    print('Invalid phone number')
if findAgeByDob(dob) != age :
    print('Invalid date of birth and age')

# Find if the given number is prime

import math
def isNumberPrime(num):
    isPrime = True
    if num <= 1 :
        return False
    else :
        for i in range(2, int(math.sqrt(num))+1) :
            if num % i == 0 :
                isPrime = False
                break
        return isPrime
    
num = int(input('Enter a number : '))
if isNumberPrime(num): 
    print(f'{num} is a prime number')
else :
    print(f'{num} is not a prime number')


# Take 10 numbers and find the average of all the prime numbers in the collection

sum = 0

for i in range(10) :
    num = int(input('Enter a number : '))
    if isNumberPrime(num):
        sum += num

print(f'average of all the prime numbers is {sum/10}')

# Length of a given input string

inputStr = input('Enter a string :')

print(f'Length of the string is {len(inputStr)}')

# Find All Permutations of a given string

def find_permutations(s):
    if len(s) == 1:
        return [s]

    permutations = []
    for i, char in enumerate(s):
        remaining_chars = s[:i] + s[i+1:]
        for perm in find_permutations(remaining_chars):
            permutations.append(char + perm)

    return permutations

input_string = input('Enter a string : ')
all_permutations = find_permutations(input_string)
print(f'All permutations of "{input_string}":')
for perm in all_permutations:
    print(perm)

#  Print a pyramid of starts for the number of rows specified
#    *
#   ***
# ******

def print_pyramid(rows):
    for i in range(rows):
        for j in range(rows - i - 1):
            print(' ', end='')
        for j in range(2 * i + 1):
            print('*', end='')
        
        print()

rows = int(input('Enter the number of rows: '))
print_pyramid(rows)