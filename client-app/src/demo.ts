interface Duck{
    name: string;
    numLegs: number;
    makeSound: (sound: string) => void;

}

const duck1: Duck = {
name: 'abc',
numLegs: 2,
makeSound: () => console.log('quack')
}

duck1.makeSound('sdfs');
duck1.name = '3';


export const ducks = [duck1] 