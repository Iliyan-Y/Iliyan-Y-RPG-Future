const express = require('express');
const app = express();
const http = require('http');
const server = http.createServer(app);
const { Server } = require('socket.io');
const io = new Server(server);

// app.get('/', (req, res) => {
//   res.sendFile(__dirname + '/index.html');
// });

// io.use((socket, next) => {
//   if (socket.handshake.query.token === 'UNITY') {
//     next();
//   } else {
//     next(new Error('Authentication error'));
//   }
// });

io.on('connection', (socket) => {
  console.log('connection');
  console.log(socket.handshake.query.token);

  setTimeout(() => {
    socket.emit('connection', {
      date: new Date().getTime(),
      data: 'Hello Unity',
    });
  }, 1000);

  socket.on('hello', (data) => {
    console.log('hello', data);
    socket.emit('hello', { date: new Date().getTime(), data: data });
  });

  socket.on('spin', (data) => {
    console.log('spin');
    socket.emit('spin', { date: new Date().getTime(), data: data });
  });

  socket.on('class', (data) => {
    console.log('class', data);
    socket.emit('class', { date: new Date().getTime(), data: data });
  });

  socket.on('disconnect', () => {
    console.log('user disconnected');
  });
});

server.listen(3000, () => {
  console.log('listening on *:3000');
});
