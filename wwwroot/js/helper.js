
// Updates the words dropdown menu based on selected category
function UpdateWords()
{

    $('#words').empty();
   
    fetch("/api/Requests", {

        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
           
        },
        body: JSON.stringify('http://localhost/RunningHillAPI/getWords/' + $('#categories').val()),


    })
        .then((response) => {
            console.log("response ", response)
            return response.text();
        })
        .then((result) => {

            console.log("result ",result)
            const myArray = result.replace(/"/g, '').split(",");

            for (let i = 0; i < myArray.length; i++) {
                $('#words').append(new Option(myArray[i], myArray[i]));
            }
          
        });
}



// add word to sentence

function addWord() {
    $('#sentence').append($('#words').val()+" ")
}


// store sentence

function addSentence()
{
    let posted = { "dest": "http://localhost/RunningHillAPI/PostSentence/", "sentence": $('#sentence').text()}
    let dest = "http://localhost/RunningHillAPI/PostSentence/";
    let sent = $('#sentence').text();
    console.log()
    fetch("/api/PostSentFrt", {

        method: 'POST',
        headers: {
            'Content-Type': 'application/json'

        },
        body: JSON.stringify({ dest, sent }),

    })
        .then((response) => {
            console.log("response ", response)
            return response.text();
        })
        .then((result) => {
            console.log("result ", result)
            $('#postresult').text(result);
         
        });

}