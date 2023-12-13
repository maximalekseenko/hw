func = (data) => {
    let nums = data.toString().split(' ').map(function (x){return parseInt(x)});
    let peakIndex;
    let ascending = true;
    
    function isHill(mas) {
        var isDesc = true;
        var isAsc = true;

        for (let i=0, l=nums.length-1; i<l; i++){
           isDesc = isDesc && (nums[i] > nums[i+1]);
           isAsc = isAsc && (nums[i] < nums[i+1]);
        }
        
        if (isDesc) {return false};
        
        for (let i = 1; i < nums.length; i++){
            if (nums[i] == nums[i - 1]) {
                return false;  
            };
            
            if (nums[i] < nums[i - 1] && ascending == true) {
                peakIndex = i - 1;
                ascending = false;
            } else if (nums[i] > nums[i - 1] && ascending == false) {
                return false;
            }
        };
        
        if (!ascending) {
            return true;
        };
    }
    
    is_hill = isHill(nums);
    return is_hill ? `yes ${peakIndex}` : "no";
};

process.stdin.on('data', data => {
    let res = func(data);    
    process.stdout.write(res + '');
    process.exit();
});

2.6

divisors = (data) => {    
	let chisl = parseInt(data.toString());
    let mas = [];    
    for (let i = 2; i < chisl; i++){
        if (chisl % i == 0){            
            mas.push(i);
    	}    
   	}
    
    if (mas == 0){        
    return chisl.toString() + " является простым";
    }    
    else {
        return `[${mas.join(', ')}]`;
    };
};

let cnt, res;
process.stdin.on('data', data => {
    res = divisors(data);    
    process.stdout.write(res + '');
    process.exit();
});



