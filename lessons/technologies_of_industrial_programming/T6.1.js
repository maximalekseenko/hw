
function sleep(__delay) {  
  return new Promise(_resolve => setTimeout(_resolve, __delay));
}

function invokeAfterDelay(__func, __delay) {
  return sleep(__delay).then(__func);
}

func = (id)=>console.log(`running ${id}`);
async function Run() {
  invokeAfterDelay(()=>{func(1)}, 2000);
  invokeAfterDelay(()=>{func(2)}, 1000);
  
  await sleep(3000);

  invokeAfterDelay(()=>{func(3)}, 2000)
      .then(
          invokeAfterDelay(()=>{func(4)}, 1000)
      );
  await sleep(3000);

}
Run();
