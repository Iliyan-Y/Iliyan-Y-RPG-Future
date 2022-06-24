const User = require('../../Models/User');
const { v4: uuidv4 } = require('uuid');

const createUser = async (req, res) => {
  try {
    const email = req.body.email;
    const position = req.body.position;
    const id = uuidv4();
    const user = await User.query().insert({ email, position, id });
    return res.status(200).json(user);
  } catch (error) {
    return res.status(400).json(error);
  }
};

module.exports = createUser;
