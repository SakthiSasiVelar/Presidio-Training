class Student{
    constructor(name, age){
       if(this.constructor === Student){
        throw new Error('Cannot instantiate abstract class');
       }
        this.name = name;
        this.age = age;
    }
    getAge(){
        return this.age;
    }

    getDetails(){    //polymorphism
        return `${this.name} is ${this.age} years old`;
    }
}

//Inheritance
class Subject extends Student{
    #subject;
    constructor(name, age, subject){
        super(name, age);
        this.#subject = subject;
    }
    getSubject(){
        return this.#subject;
    }
    
    getDetails(){       // polymorphism
        return `${this.name} is ${this.age} years old and studies ${this.#subject}`;
    }

}

try{
    let student1 = new Student('John', 20); // abstraction (cannot create obj for abstract class);
}
catch(error){
    console.log(error.message);
}

let subject1 = new Subject('John',20,'english')
console.log(subject1.getDetails()) // polymorphism


console.log(subject1.getSubject()); // encapsulation


// prototype based inheritance

let person = {
    name: 'John',
    age: 20,
    getDetails: function(){
        return `${this.name} is ${this.age} years old`;
    }
}

let subject = {
    subject: 'english',
    getDetails: function(){
        return `${this.name} is ${this.age} years old and studies ${this.subject}`;
    }
}
console.log(subject.getDetails())  // name and age is undefined 
subject.__proto__ = person ;

console.log(subject.getDetails());  // name and age is not undefined since subject has person prototype.