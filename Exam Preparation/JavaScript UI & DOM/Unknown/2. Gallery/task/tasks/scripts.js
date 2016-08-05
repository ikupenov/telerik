// funa
$.fn.gallery = function (columns) {
  columns = columns || 4;

  function mod(n, m) {
    return ((n % m) + m) % m;
  }

  function updateImages(imgIndex) {
    return $galleryList
      .children()
      .eq(mod(imgIndex, galleryListLen))
      .children()
      .attr('src');
  }

  var $galleryList = $('.gallery-list'),
    $selected = $('.selected'),
    $imageContainers = $('.image-container'),
    $current = $('#current-image'),
    $previous = $('#previous-image'),
    $next = $('#next-image'),
    galleryListLen = $galleryList.children().length,
    currImgIndex;

  $('#gallery').addClass('gallery');

  $selected.hide();

  $imageContainers.each(function (i, el) {
    if (i % columns === 0) {
      $(el).addClass('clearfix');
    }
  });

  $galleryList.on('click', function (ev) {
    var $target = $(ev.target);

    if (!$galleryList.hasClass('disabled-background')) {
      $current.attr('src', $target.attr('src'));
      currImgIndex = $target.parent().index();

      $next.attr('src', updateImages(currImgIndex + 1));
      $previous.attr('src', updateImages(currImgIndex - 1));

      $galleryList.addClass('blurred');
      $galleryList.addClass('disabled-background');
      $selected.show();
    }
  });

  $selected.on('click', function (ev) {
    var $target = $(ev.target);

    if ($target.parent().hasClass('current-image')) {
      $selected.hide();
      $galleryList.removeClass('blurred');
      $galleryList.removeClass('disabled-background');
    } else {
      if ($target.parent().hasClass('next-image')) {
        currImgIndex = mod(currImgIndex + 1, galleryListLen);
      } else if ($target.parent().hasClass('previous-image')) {
        currImgIndex = mod(currImgIndex - 1, galleryListLen);
      }

      $current.attr('src', updateImages(currImgIndex));
      $next.attr('src', updateImages(currImgIndex + 1));
      $previous.attr('src', updateImages(currImgIndex - 1));
    }
  });
};
// }

// module.exports = solve;