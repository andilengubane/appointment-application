const basePath = "https://localhost:5001";

export const getItems = () => fetch(basePath).then((data) => data.json());

export const createItem = (title) =>
  fetch(basePath, {
    method: "POST",
    body: JSON.stringify({ title }),
  });

export const markItemAsDone = (itemId) =>
  fetch(`${basePath}/${itemId}/done`, {
    method: "PUT",
  });

export const deleteItem = (itemId) =>
  fetch(`${basePath}/${itemId}`, {
    method: "DELETE",
  });