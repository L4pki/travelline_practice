import * as fs from 'fs';
import * as path from 'path';

const extractLinks = (htmlContent: string): string[] => {
  const regex = /href="([^"]+)"|src="([^"]+)"/g;
  const links: string[] = [];
  let match: RegExpExecArray | null;

  while ((match = regex.exec(htmlContent)) !== null) {
    links.push(match[1] || match[2]);
  }

  return links;
};

const htmlResources = (filePath: string): void => {
  const fullPath = path.resolve(filePath);
  fs.readFile(fullPath, 'utf8', (err, htmlContent) => {
    if (err) {
      console.error('Ошибка при чтении файла:', err);
      return;
    }

    const links = extractLinks(htmlContent);
    console.log(JSON.stringify(links, null, 2));
  });
};

const [, , command, filePath] = process.argv;

if (command === 'html-resources' && filePath) {
  htmlResources(filePath);
} else {
  console.log('Неизвестная команда');
}