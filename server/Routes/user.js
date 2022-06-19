const User = require('../Models/User');
const router = require('express').Router();
const { v4: uuidv4 } = require('uuid');

// List articles
router.get('/', async (req, res, next) => {
  const users = await User.query();
  return res.status(200).json(users);
});

// // Show article
// router.get('/:id', async (req, res, next) => {
//   if (req.params.id === 'new') {
//     return next();
//   }
//   const article = await Article.query().findById(req.params.id);

//   return res.render('articles/show', {
//     title: article.title,
//     article,
//   });
// });

// New article
// router.get('/new', (req, res, next) => {
//   return res.status(200).json();
//   // return res.render('users/new', {
//   //   // title: 'New article',
//   // });
// });
//Create an article
router.post('/', async (req, res, next) => {
  try {
    const email = req.body.email;
    const position = { x: 1, y: 2, z: 0 };
    const id = uuidv4();
    const user = await User.query().insert({ email, position, id });
    return res.status(200).json(user);
  } catch (error) {
    res.status(400).json(error);
  }
});
// // Edit article
// router.get('/:id/edit', async (req, res, next) => {
//   const article = await Article.query().findById(req.params.id);

//   return res.render('articles/edit', {
//     title: 'Edit article',
//     article,
//   });
// });
// // Update an article
// router.patch('/:id', async (req, res, next) => {
//   const title = req.body.title;
//   const text = req.body.text;
//   await Article.query().findById(req.params.id).patch({ title, text });
//   return res.redirect(`/articles/${req.params.id}`);
// });
// // Delete an article
// router.delete('/:id', async (req, res, next) => {
//   await Article.query().deleteById(req.params.id);
//   return res.redirect('/articles');
// });
module.exports = router;
