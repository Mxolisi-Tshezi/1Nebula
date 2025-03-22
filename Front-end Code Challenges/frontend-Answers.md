# Front-end Code Challenges Solutions

## Question 1

```html
<div id="firstDiv" class="red-card">
  <div id="secondDiv" class="red-card">
    <style>
      #secondDiv {
        background: orange;
      }

      div {
        height: 150px;
        width: 150px;
        background: green;
      }

      .red-card {
        background: red;
      }

      .yellow-card {
        background: yellow;
      }
    </style>
  </div>
</div>
```

### 1. What will the colour of both div elements be?

- **firstDiv**: The color will be **red**.

  - Since the `.red-card` class has higher specificity than the general `div` selector, `firstDiv` will be red

- **secondDiv**: The color will be **orange**.
  - The `#secondDiv` selector has the highest specificity (ID selector)
  - So `secondDiv` will have `background: orange`

### 2. How would you dynamically target `firstDiv` and make its colour pink?

```javascript
// by vanilla JavaScript
document.getElementById("firstDiv").style.backgroundColor = "pink";

// or if Iuse jQuery
$("#firstDiv").css("backgroundColor", "pink");
```

### 3. How would you dynamically target `secondDiv` and add the `yellow-card` class to its class list?

```javascript
// Using vanila js
document.getElementById("secondDiv").classList.add("yellow-card");

// jQuery
$("#secondDiv").addClass("yellow-card");
```

## Question 2

Regarding the `compareIt` function:

```javascript
function compareIt(num1, num2) {
  return num1 == num2;
}

compareIt(5, "5");
```

### 1. Why will the function call return true?

The function call `compareIt(5, "5")` returns `true` because the double equals operator (`==`) performs type coercion. It attempts to convert the operands to the same type before comparison. In this case, it converts the string `"5"` to the number `5` before comparing, which makes them equal.

### 2. How could one change this function so that data types are checked as well as values?

```javascript
function compareIt(num1, num2) {
  return num1 === num2;
}
```

Using the triple equals operator (`===`) performs a strict equality comparison that checks both value and type without coercion. With this change, `compareIt(5, "5")` would return `false` because a number and a string are different types.

## Question 3

### 1. How would you make a web page mobile friendly (i.e responsive)?

To make a web page responsive:

**Use viewport meta tag:**

```html
<meta name="viewport" content="width=device-width, initial-scale=1.0" />
```

**Use responsive CSS units:**

```css
/* Use relative units instead of fixed pixel values */
.container {
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
}
```

**Implement media queries:**

```css
/* Desktop styles */
.navigation {
  display: flex;
}

/* Tablet styles */
@media (max-width: 768px) {
  .navigation {
    flex-direction: column;
  }
}

/* Mobile styles */
@media (max-width: 480px) {
  .navigation {
    font-size: 0.8rem;
  }
}
```

**Use CSS Flexbox and Grid:**

```css
.container {
  display: flex;
  flex-wrap: wrap;
}

.item {
  flex: 1 1 300px; /* Grow, shrink, and base width */
}
```

**Use responsive images:**

```html
<img
  src="image.jpg"
  alt="Responsive image"
  style="max-width: 100%; height: auto;"
/>
```

### 2. What is the benefit of bundling .js scripts into one file?

- **Reduced HTTP requests**: Fewer files mean fewer server requests, improving load time
- **Improved caching**: A single file can be cached more efficiently
- **Simplified dependency management**: Proper ordering of scripts is handled by the bundler
- **Code optimization**: Bundlers typically include minification and tree-shaking to reduce file size
- **Code transformations**: Bundlers can apply transformations like transpilation and polyfills

### 3. What needs to be done to ensure the browser understands Sass styling?

The browser doesn't understand Sass directly. To use Sass:

1. **Compile Sass to CSS**: Use a Sass compiler/preprocessor (like `sass`, `node-sass`, or build tools like Webpack, Gulp, etc.)
2. **Include the compiled CSS**: Link the compiled CSS file in your HTML, not the Sass file
3. **Use a build process**: Integrate Sass compilation into your development workflow

Example build process using npm scripts:

```json
"scripts": {
  "sass": "sass src/styles.scss public/styles.css",
  "sass:watch": "sass --watch src/styles.scss public/styles.css"
}
```

### 4. What should be done to ensure browser compatibility with newer flavors of JavaScript like ES6/7?

To ensure browser compatibility with modern JavaScript:

1. **Use a transpiler like Babel**: Convert modern JS to ES5 that works in older browsers

   ```json
   {
     "presets": ["@babel/preset-env"]
   }
   ```

2. **Use polyfills**: Include polyfills for missing browser features

   ```javascript
   import "core-js/stable";
   import "regenerator-runtime/runtime";
   ```

3. **Configure browser targets**: Specify which browsers to support

   ```json
   {
     "browserslist": ["> 1%", "last 2 versions", "not dead"]
   }
   ```

4. **Use a bundler with Babel integration**: Tools like Webpack, Rollup, or Parcel can automate this process

5. **Feature detection**: Check for feature support before using it
   ```javascript
   if (Array.prototype.includes) {
     // Use includes
   } else {
     // Use alternative
   }
   ```
