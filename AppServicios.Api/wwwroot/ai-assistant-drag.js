// Drag & Drop para el asistente IA flotante
(function() {
  const ai = document.getElementById('aiAssistant');
  let isDragging = false;
  let offsetX = 0;
  let offsetY = 0;

  if (!ai) return;

  const btn = document.getElementById('aiAssistantBtn');
  btn.style.cursor = 'grab';

  btn.addEventListener('mousedown', function(e) {
    isDragging = true;
    offsetX = e.clientX - ai.getBoundingClientRect().left;
    offsetY = e.clientY - ai.getBoundingClientRect().top;
    ai.style.transition = 'none';
    document.body.style.userSelect = 'none';
  });

  document.addEventListener('mousemove', function(e) {
    if (!isDragging) return;
    ai.style.left = 'unset';
    ai.style.top = 'unset';
    ai.style.right = 'auto';
    ai.style.bottom = 'auto';
    ai.style.position = 'fixed';
    ai.style.zIndex = 1002;
    ai.style.transform = `translate(${e.clientX - offsetX}px, ${e.clientY - offsetY}px)`;
  });

  document.addEventListener('mouseup', function() {
    if (isDragging) {
      isDragging = false;
      ai.style.transition = '';
      document.body.style.userSelect = '';
    }
  });
})();
