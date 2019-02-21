import java.sql.*;
import static java.sql.DriverManager.getConnection;

public class Main {

    private static Statement statement;

    public static void main(String[] args) throws Exception {

        Connection connect = getConnection("jdbc:mysql://localhost/projectli", "root", "");
        statement = connect.createStatement();
        export(statement);
    }

    public static void export(Statement statement) throws Exception {

        statement.executeQuery("SELECT * FROM ability INTO OUTFILE '/tmp/ability.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM account INTO OUTFILE '/tmp/account.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM class INTO OUTFILE '/tmp/class.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM instances INTO OUTFILE '/tmp/instances.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM item INTO OUTFILE '/tmp/item.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM monster INTO OUTFILE '/tmp/monster.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
        statement.executeQuery("SELECT * FROM player INTO OUTFILE '/tmp/player.csv' FIELDS TERMINATED BY ',' ENCLOSED BY '\"' LINES TERMINATED BY '\n'");
    }
}
