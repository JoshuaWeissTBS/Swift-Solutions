export function UnauthorizedError(message = "") {
  this.name = "UnauthorizedError";
  this.message = message;
}
UnauthorizedError.prototype = Error.prototype;
