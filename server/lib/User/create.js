const User = require('../../Models/User');
const { v4: uuidv4 } = require('uuid');

const createUser = async (req, res) => {
  let body = JSON.parse(Object.keys(req.body)[0]);
  try {
    const email = body.email;
    if (!email) throw 'email required';
    const position = body.position;
    const id = uuidv4();
    const user = await User.query().insert({ email, position, id });
    return res.status(200).json(user);
  } catch (error) {
    console.log('Create User ERROR');
    console.log(error);
    return res.status(400).json(error);
  }
};

module.exports = createUser;
