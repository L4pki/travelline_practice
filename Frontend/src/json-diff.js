"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var fs = require("fs");
function readJsonFile(filePath) {
    try {
        var fileContent = fs.readFileSync(filePath, 'utf-8');
        return JSON.parse(fileContent);
    }
    catch (error) {
        console.error("\u041E\u0448\u0438\u0431\u043A\u0430 \u043F\u0440\u0438 \u0447\u0442\u0435\u043D\u0438\u0438 \u0444\u0430\u0439\u043B\u0430 ".concat(filePath, ":"), error);
        process.exit(1);
    }
}
function compareJsonObjects(oldObj, newObj) {
    var diff = {};
    for (var key in oldObj) {
        if (!(key in newObj)) {
            diff[key] = { type: 'deleted', oldValue: oldObj[key] };
        }
        else if (JSON.stringify(oldObj[key]) !== JSON.stringify(newObj[key])) {
            diff[key] = { type: 'changed', oldValue: oldObj[key], newValue: newObj[key] };
        }
        else {
            diff[key] = { type: 'unchanged', oldValue: oldObj[key], newValue: newObj[key] };
        }
    }
    for (var key in newObj) {
        if (!(key in oldObj)) {
            diff[key] = { type: 'new', newValue: newObj[key] };
        }
    }
    return diff;
}
function jsonDiff(oldFilePath, newFilePath) {
    var oldJson = readJsonFile(oldFilePath);
    var newJson = readJsonFile(newFilePath);
    var diffResult = compareJsonObjects(oldJson, newJson);
    console.log(JSON.stringify(diffResult, null, 2));
}
// Пример использования:
// jsonDiff('../fixtures/json-diff/simple/old.json', '../fixtures/json-diff/simple/new.json');
// Для запуска этой функции из командной строки, вы можете использовать следующий код:
var args = process.argv.slice(2);
if (args[0] === 'json-diff' && args.length === 3) {
    jsonDiff(args[1], args[2]);
}
else {
    console.log('Использование: node 1-tools.js json-diff <путь к old.json> <путь к new.json>');
}
