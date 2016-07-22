function solve () {
  return function (element, contents) {
    if (typeof (element) === 'string') {
      element = document.getElementById(element);
      if (!element) {
        throw new Error();
      }
    }
    else if (!(element instanceof HTMLElement)) {
      throw new Error();
    }

    var fragment = document.createDocumentFragment(),
      len = contents.length, i;

    for (i = 0; i < len; i += 1) {
      var content = contents[i],
        div = document.createElement('div');

      if (typeof (content) !== 'string' && typeof(content) !== 'number') {
        throw new Error();
      }

      div.innerHTML = content;
      fragment.appendChild(div);
    }

    element.innerHTML = '';
    element.appendChild(fragment);
  }
}