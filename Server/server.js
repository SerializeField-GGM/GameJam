const ws = require('ws');
const server = new ws.Server({ port: 8081 });

const fs = require('fs');
const dataFile = './Json/playerData.json';
const namesFile = './Json/names.json';

let scoreData = {};
let names = [];

if (fs.existsSync(dataFile) && fs.readFileSync(dataFile) != "")
    scoreData = JSON.parse(fs.readFileSync(dataFile));
if (fs.existsSync(namesFile) && fs.readFileSync(namesFile) != "")
    names = JSON.parse(fs.readFileSync(namesFile));

server.on('listening', () => {
    console.log("서버가 열렸습니다!");
});

server.on('connection', client => {
    client.on('message', message => {
        const type = message.toString().split(':')[0];
        const data = message.toString().split(':')[1];

        switch (type) {
            case 'init':
                server.clients.forEach(c => {
                    SendScore(c);
                    SendNames(c);
                });
                break;
            case 'score':
                const nickname = data.split(',')[0];
                const fame = data.split(',')[1];

                scoreData[nickname] = fame;

                fs.writeFileSync(dataFile, JSON.stringify(scoreData));
                server.clients.forEach(c => SendScore(c));
                break;
            case 'nickname':
                const name = data;
                let isMatch = false;
                names.forEach(i => {
                    if (i === name) isMatch = true;
                });

                if (!isMatch) {
                    names.push(name);
                    fs.writeFileSync(namesFile, JSON.stringify(names));
                    server.clients.forEach(c => SendNames(c));
                }
                else
                    client.send('error:이미 사용중인 닉네임입니다.');
                
                break;
        }
    });
});

function SendNames(client) {
    let data = 'name:' + names.join('|');
    client.send(data);
}

function SendScore(client) {
    let data = 'score:' + Object.keys(scoreData).map((key) => {
        if(key.length == 0) return;
        return key + ',' + scoreData[key];
    }).join('|');
    client.send(data);
}