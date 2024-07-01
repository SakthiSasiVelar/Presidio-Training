
# Longest Substring Without Repeating Characters. That is in a given string find the longest substring that does not contain any character twice.

def longest_substring_without_repeating(s):
    char_index_map = {}
    start = 0
    max_length = 0
    longest_substr = ""

    for end, char in enumerate(s):
        if char in char_index_map and char_index_map[char] >= start:
            start = char_index_map[char] + 1
        char_index_map[char] = end
        current_length = end - start + 1
        if current_length > max_length:
            max_length = current_length
            longest_substr = s[start:end + 1]

    return longest_substr

s = input("Enter a string : ")
print(longest_substring_without_repeating(s))


# Print the list of prime numbers up to a given number

def is_prime(num):
    if num < 2:
        return False
    for i in range(2, int(num ** 0.5) + 1):
        if num % i == 0:
            return False
    return True

num = int(input("Enter the range : "))
prime_numbers = []
for i in range(num) :
    if is_prime(i):
        prime_numbers.append(i)
print(prime_numbers)


# Sort score and name of players print the top 10


players = [
        ('Alice', 88),
        ('Bob', 95),
        ('Charlie', 70),
        ('David', 65),
        ('Eve', 90),
        ('Frank', 85),
        ('Grace', 92),
        ('Hannah', 78),
        ('Ivy', 83),
        ('Jack', 96),
        ('Karen', 82),
        ('Leo', 91)
    ]

sorted_players = sorted(players, key=lambda player: player[1], reverse=True)

top_10_players = sorted_players[:10]

print("Top 10 Players:")
for rank, (name, score) in enumerate(top_10_players, start=1):
    print(f"{rank}. {name} - {score}")


 # Application to play the Cow and Bull game maintain score as well. - reff - Wordle of New York Times

import random

# List of possible 4-letter words
words = ["play", "word", "game", "code", "java", "ruby", "node", "quiz"]

# Function to calculate cows and bulls
def calculate_cows_and_bulls(secret, guess):
    bulls = sum(s == g for s, g in zip(secret, guess))
    cows = len(set(secret) & set(guess)) - bulls
    return cows, bulls

def cow_and_bull_game():
    secret_word = random.choice(words)
    score = 0
    attempts = 0
    max_attempts = 10

    print("Welcome to the Cow and Bull game!")
    print(f"Guess the 4-letter word. You have {max_attempts} attempts.")
    
    while attempts < max_attempts:
        guess = input("Enter your guess: ").strip().lower()
        
        if len(guess) != 4:
            print("Please enter a 4-letter word.")
            continue
        
        cows, bulls = calculate_cows_and_bulls(secret_word, guess)
        attempts += 1
        score = max(0, score + bulls - cows)  # Adjust score based on feedback
        
        print(f"Attempt {attempts}: {guess} -> {bulls} Bulls, {cows} Cows")
        
        if bulls == 4:
            print(f"Congratulations! You've guessed the word '{secret_word}' correctly in {attempts} attempts.")
            break
    else:
        print(f"Sorry, you've used all {max_attempts} attempts. The word was '{secret_word}'.")

    print(f"Your final score is: {score}")

cow_and_bull_game()

# Credit card validation - Luhn check algorithm

def luhn_check(card_number):
    digits = [int(d) for d in str(card_number)]
    for i in range(len(digits) - 2, -1, -2):
        digits[i] *= 2
        if digits[i] > 9:
            digits[i] -= 9 
    total = sum(digits)
    return total % 10 == 0

card_number = input("Enter the credit card number: ").strip()
    
if luhn_check(card_number):
    print("The credit card number is valid.")
else:
    print("The credit card number is invalid.")