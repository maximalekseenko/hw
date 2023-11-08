class Human {
    constructor(name, surname) {
        this.name = name;
        this.surname = surname;
    }
    comp(other) {
        if (this.surname != other.surname) 
            return this.surname > other.surname;
        else return this.name > other.name;
    }
}

  

solve = (data) => {
    human1 = new Human("1", "A");
    human2 = new Human("1", "B");
    human3 = new Human("2", "B");

    return "1 > 2 : " + human1.comp(human2) +
         "\n2 > 3 : " + human2.comp(human3) +
         "\n3 > 1 : " + human3.comp(human1);
};


process.stdin.on('data', data => {
    let res = solve(data.toString());
    process.stdout.write(res + '');
    process.exit();
});
