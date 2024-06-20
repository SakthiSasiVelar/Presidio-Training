const { JSDOM } = require('jsdom');
const fs = require('fs');
const path = require('path');

const loadPage = () => {
    const html = fs.readFileSync(path.resolve(__dirname, '../index.html'), 'utf8');
    const js = fs.readFileSync(path.resolve(__dirname, '../login.js'), 'utf8');
    const dom = new JSDOM(html, { runScripts: 'dangerously', resources: 'usable' });
    const script = dom.window.document.createElement('script');
    script.textContent = js;
    dom.window.document.body.appendChild(script);
    return dom;
}

test('Test login validation', () => {
    const dom = loadPage();
    dom.window.document.getElementById('form').dispatchEvent(new dom.window.Event('submit'));
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('All fields are required');
});

test('Test login sucess', () => {
    const dom = loadPage();
    dom.window.document.getElementById('email').value = 'rohit@gmail.com';
    dom.window.document.getElementById('password').value = 'rohit123';

    dom.window.document.getElementById('form').dispatchEvent(new dom.window.Event('submit'));
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('login successful');
});

test('Test login failure', () => {
    const dom = loadPage();
    dom.window.document.getElementById('email').value = 'sachin@gmail.com';
    dom.window.document.getElementById('password').value = 'sachin123';

    dom.window.document.getElementById('form').dispatchEvent(new dom.window.Event('submit'));
    const actual = dom.window.document.getElementById('message').innerHTML;
    expect(actual).toBe('Invalid email or password');
});