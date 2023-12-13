const IMPORT_URL = 'https://wh40k.lexicanum.com/wiki/Dark_Angels';

function FindUrls(text){
    console.log(url)
}

fetch(IMPORT_URL).then(
    reply => reply.text().then(
        text => {
            text.match(/<img.*?src="(.*?)"[^>]*>/g).forEach(
                _img => console.log(_img)
            )
        }
    )
);