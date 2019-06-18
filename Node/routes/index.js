var express = require("express");
var router = express.Router();

/* GET home page. */
router.get("/", function(req, res, next) {
  console.log(
    "logging env variables(passed through Azure):",
    process.env.PORT,
    process.env.CONNECTION_STRING,
    process.env.CUSTOMCONNSTR_MONGO_DB

    // SQL Server: SQLCONNSTR_
    // MySQL: MYSQLCONNSTR_
    // SQL Database: SQLAZURECONNSTR_
    // Custom: CUSTOMCONNSTR_
  );
  res.render("index", {
    title: "your first Azure Node application deployment"
  });
});

module.exports = router;
