import * as fs from 'fs';

type JsonValue = string | number | boolean | null | JsonValue[] | { [key: string]: JsonValue };
type DiffStatus = 'changed' | 'deleted' | 'new' | 'unchanged';

interface DiffResult {
  type: DiffStatus;
  oldValue?: JsonValue;
  newValue?: JsonValue;
}

function readJsonFile(filePath: string): any {
  try {
    const fileContent = fs.readFileSync(filePath, 'utf-8');
    return JSON.parse(fileContent);
  } catch (error) {
    console.error(`Ошибка при чтении файла ${filePath}:`, error);
    process.exit(1);
  }
}

function compareJsonObjects(oldObj: any, newObj: any): { [key: string]: DiffResult } {
  const diff: { [key: string]: DiffResult } = {};

  for (const key in oldObj) {
    if (!(key in newObj)) {
      diff[key] = { type: 'deleted', oldValue: oldObj[key] };
    } else if (JSON.stringify(oldObj[key]) !== JSON.stringify(newObj[key])) {
      diff[key] = { type: 'changed', oldValue: oldObj[key], newValue: newObj[key] };
    } else {
      diff[key] = { type: 'unchanged', oldValue: oldObj[key], newValue: newObj[key] };
    }
  }

  for (const key in newObj) {
    if (!(key in oldObj)) {
      diff[key] = { type: 'new', newValue: newObj[key] };
    }
  }

  return diff;
}

function jsonDiff(oldFilePath: string, newFilePath: string): void {
  const oldJson = readJsonFile(oldFilePath);
  const newJson = readJsonFile(newFilePath);

  const diffResult = compareJsonObjects(oldJson, newJson);
  console.log(JSON.stringify(diffResult, null, 2));
}

const args = process.argv.slice(2);
if (args[0] === 'json-diff' && args.length === 3) {
  jsonDiff(args[1], args[2]);
} else {
  console.log('Использование: node json-diff.js json-diff <путь к old.json> <путь к new.json>');
}