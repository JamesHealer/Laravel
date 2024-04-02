
export function formatDate(date: Date | string, long = true, second = false) {
    if(typeof(date) === 'string') return date;

    var d = new Date(date),
      month = "" + (d.getMonth() + 1),
      day = "" + d.getDate(),
      year = d.getFullYear();
  
    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;
    if(long) {
      let hours = "" + d.getHours();
      let mins = "" + d.getMinutes();
      let seconds = "" + d.getSeconds();
      if (hours.length < 2) hours = "0" + hours;
      if (mins.length < 2) mins = "0" + mins;
      if (seconds.length < 2) seconds = "0" + seconds;
      return ([day, month, year].join("/") + " " + [hours, mins].join(":")) + (second ? `:${seconds}` : '');
    } else {
      return [day, month, year].join("/");
    }
}
export function formatTime(date: Date | string) {
    if(typeof(date) === 'string') return date;

    if(!date) return "";
    var d = new Date(date);
    let hours = "" + d.getHours();
    let mins = "" + d.getMinutes();
    if (hours.length < 2) hours = "0" + hours;
    if (mins.length < 2) mins = "0" + mins;
    return [hours, mins].join(":");
}
export function getAttr(key: string, keyVal: any, attrName: string, defaultVal: any, arr: any[]) {
    const obj = arr.find(a => {
        if(typeof(keyVal) === 'string') {
            return (a[key] as string).toLowerCase() === keyVal.toLowerCase();
        } else {
            return a[key] == keyVal;
        }
    });
    if(!obj) return defaultVal;
    return obj[attrName];
}