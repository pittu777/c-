


function sum(){
    let sum = 0;
    const inner=(...args)=>{
        if(args.length !== 0){

            sum+=args[0];
            
        }
        return sum;
    }
    return inner;

}