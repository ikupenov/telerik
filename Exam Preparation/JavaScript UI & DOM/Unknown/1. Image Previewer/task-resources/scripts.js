// function solve() {
function createImagesPreviewer(selector, items) {
  var root = document.querySelector(selector);

  var preview = document.createElement('div');
  preview.style.cssFloat = 'left';
  preview.style.width = '500px';
  preview.style.height = '400px';
  preview.style.textAlign = 'center';
  preview.className += 'image-preview';

  var previewTitle = document.createElement('h1');
  previewTitle.innerHTML = items[0].title;

  var previewImg = document.createElement('img');
  previewImg.style.borderRadius = '10px';
  previewImg.style.width = '80%';
  previewImg.src = items[0].url;

  preview.appendChild(previewTitle);
  preview.appendChild(previewImg);

  var aside = document.createElement('div');
  aside.style.cssFloat = 'left';
  aside.style.width = '250px';
  aside.style.height = '400px';
  aside.style.textAlign = 'center';

  var filterLabel = document.createElement('label');
  filterLabel.style.display = 'block';
  filterLabel.innerHTML = 'Filter';

  var filterBox = document.createElement('input');
  filterBox.style.width = '80%';
  filterBox.style.height = '15px';

  var gallery = document.createElement('ul');
  gallery.style.listStyleType = 'none';
  gallery.style.padding = '0';
  aside.style.overflowY = 'scroll';

  for (var i = 0; i < items.length; i += 1) {
    var item = document.createElement('li');
    item.style.textAlign = 'center';
    item.className += 'image-container';

    var title = document.createElement('h3');
    title.className += 'title';
    title.innerHTML = items[i].title;
    title.style.margin = '0';

    var img = document.createElement('img');
    img.className += 'img';
    img.src = items[i].url;
    img.style.width = '70%';
    img.style.height = '120px';

    item.appendChild(title);
    item.appendChild(img);

    gallery.appendChild(item);
  }

  gallery.addEventListener('mouseover', function (ev) {
    if (ev.target.parentElement.className === 'image-container') {
      ev.target.parentElement.style.backgroundColor = '#C9CBD2';
    } else if (ev.target.className === 'image-container') {
      ev.target.style.backgroundColor = '#C9CBD2';
    }
  });

  gallery.addEventListener('mouseout', function (ev) {
    if (ev.target.parentElement.className === 'image-container') {
      ev.target.parentElement.style.backgroundColor = '';
    } else if (ev.target.className === 'image-container') {
      ev.target.style.backgroundColor = '';
    }
  });

  gallery.addEventListener('click', function (ev) {
    if (ev.target instanceof HTMLImageElement) {
      var title = ev.target.parentNode.getElementsByClassName('title')[0].innerHTML;
      previewTitle.innerHTML = title;
      previewImg.src = ev.target.src;
    }
  });

  filterBox.addEventListener('input', function () {
    var inputVal = filterBox.value.toLowerCase();

    for (var i = 0; i < gallery.childNodes.length; i += 1) {
      var child = gallery.childNodes[i];
      var itemTitle = child.getElementsByClassName('title')[0].innerHTML.toLowerCase();
      if (!itemTitle.includes(inputVal)) {
        child.style.display = 'none';
      } else {
        child.style.display = '';
      }
    }
  });

  aside.appendChild(filterLabel);
  aside.appendChild(filterBox);
  aside.appendChild(gallery);

  root.appendChild(preview);
  root.appendChild(aside);
}
// }
// module.exports = solve;