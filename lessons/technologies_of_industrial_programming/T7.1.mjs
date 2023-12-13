function funA() { console.log( "function A called" ); }
function funB(attr) { console.log( `function B called with ${ attr }` ); }
function funC(attr1, attr2) { console.log( `function C called with ${ attr1 } ${ attr2 }` ); }

export default funA;
export { funB, funC }