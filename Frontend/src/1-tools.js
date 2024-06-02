"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
var path = require("path");
var extractLinks = function (htmlContent) {
    var regex = /href="([^"]+)"|src="([^"]+)"/g;
    var links = [];
    var match;
    while ((match = regex.exec(htmlContent)) !== null) {
        links.push(match[1] || match[2]);
    }
    return links;
};
var htmlResources = function (filePath) {
    var fullPath = path.resolve(filePath);
    fs.readFile(fullPath, 'utf8', function (err, htmlContent) {
        if (err) {
            console.error('Ошибка при чтении файла:', err);
            return;
        }
        var links = extractLinks(htmlContent);
        console.log(JSON.stringify(links, null, 2));
    });
};
var _a = process.argv, command = _a[2], filePath = _a[3];
if (command === 'html-resources' && filePath) {
    htmlResources(filePath);
}
else {
    console.log('Неизвестная команда');
}
