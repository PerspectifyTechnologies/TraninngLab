const express = require("express");

const app = express();

app.use(express.static('public'));

const PORT = process.env.PORT || 5500;

app.listen(PORT, ()=>{});

app.get('/', (req, res)=> res.send("Api Started..."));