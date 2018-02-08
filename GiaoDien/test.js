var str = "10000000";

var res = str.replace(/(\d)(?=(\d{3})+(?!\d))/g , function (x) {
    return x + ",";
});

console.log(res);


//
