const User = require('../Models/User');
const router = require('express').Router();
const createUser = require('../lib/User/create');

// GET

//list all users
router.get('/', async (req, res, next) => {
  const users = await User.query();
  return res.status(200).json(users);
});

router.get('/byEmail', async (req, res, next) => {
  try {
    let email = req.query.email;
    if (!email) throw 'Email is required query param';
    const user = await User.query().where('email', email);
    return res.status(200).json(user);
  } catch (error) {
    return res.status(400).json(error);
  }
});

// POST

router.post('/', createUser);

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
