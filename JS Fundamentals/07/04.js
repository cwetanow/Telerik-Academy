function solve(args) {
    let result = args[0].replace(/<\/*orgcase>/g, "");
    let lower = false;
    let upper = false;
    let start = result.indexOf("<lowcase>");
    let end = result.indexOf("</lowcase");
    let temp = result.substring(start + 9, end);
    while (start >= 0) {
        result = result.replace(temp, temp.toLowerCase());
        result = result.replace(/<lowcase>/, "");
        result = result.replace(/<\/lowcase>/, "");
        start = result.indexOf("<lowcase>");
        end = result.indexOf("</lowcase");
    }
    start = result.indexOf("<upcase>");
    end = result.indexOf("</upcase");
    temp = result.substring(start + 8, end);
    while (start >= 0) {
        result = result.replace(temp, temp.toUpperCase());
        result = result.replace(/<upcase>/, "");
        result = result.replace(/<\/upcase>/, "");
        start = result.indexOf("<upcase>");
        end = result.indexOf("</upcase");
    }
    console.log(result);
}
solve(['We are <orgcase>liViNg</orgcase> in a <upcase>yellow <lowcase>submarine</lowcase></upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.']);
