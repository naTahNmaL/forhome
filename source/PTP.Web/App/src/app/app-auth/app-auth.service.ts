import {BehaviorSubject, Observable} from "rxjs";

export class AppAuthService{
  userCheck: User = {username: 'user', password:'123'};

  user = new BehaviorSubject<User>(null);
  login(user: User ): Observable<any>{
    if(user.username == this.userCheck.username && user.password == this.userCheck.password){
      return any;
    }
  }

}
export interface AuthResponseData {
  username: string,

}
interface User{
  username: string;
  password: string
}
