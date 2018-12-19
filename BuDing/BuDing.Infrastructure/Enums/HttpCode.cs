 

namespace BuDing.Infrastructure.Enums
{
    using BuDing.Infrastructure.Attributes;

    public enum HttpCode
    {
        /// <summary>
        /// 200
        /// </summary>
        [StatusCode(200,"成功")]
        OK,
        /// <summary>
        /// 201 - Created，表示资源创建成功了
        /// </summary>
        [StatusCode(201, "资源创建成功")]
        Created,
        /// <summary>
        /// 204 - No content，成功执行，但是不应该返回任何东西
        /// </summary>
        [StatusCode(204, "成功执行，但是不应该返回任何东西")]
        NoContent,
        /// <summary>
        /// 400 - Bad request，表示API的消费者发送到服务器的请求是错误的
        /// </summary>
        [StatusCode(400, "请求错误")]
        BadRequest,
        /// <summary>
        /// 401 - Unauthorized，表示没有权限
        /// </summary>
        [StatusCode(401,"未授权")]
        Unauthorized,
        /// <summary>
        /// 403 - Forbidden，表示用户验证成功，但是该用户仍然无法访问该资源
        /// </summary>
        [StatusCode(403,"无法访问该资源")]
        Forbidden,
        /// <summary>
        /// 404 - Not found，表示请求的资源不存在
        /// </summary>
        [StatusCode(404,"资源不存在")]
        NotFound,
        /// <summary>
        /// 405 - Method not allowed，这就是当我们尝试发送请求给某个资源时，使用的HTTP方法却是不允许的，例如使用POST api/countries, 而该资源只实现了 GET，所以POST不被允许
        /// </summary> 
        [StatusCode(405, "无法使用该HTTP请求")]
        MethodNotAllowed,
        /// <summary>
        /// 406 - Not acceptable，这里涉及到了media type，例如API消费者请求的是application/xml格式的media type，而API只支持application/json
        /// </summary>
        [StatusCode(406,"不支持ContextType")]
        NotAcceptable,
        /// <summary>
        /// 409 - Conflict，表示该请求无法完成，因为请求与当前资源的状态有冲突，例如你编辑某个资源数据以后，该资源又被其它人更新了，这时你再PUT你的数据就会出现409错误；有时也用在尝试创建资源时该资源已存在的情况。
        /// </summary>
        [StatusCode(409,"请求与当前资源的状态有冲突")]
        Conflict,
        /// <summary>
        /// 415 - Unsupported media type，这个和406正好返回来，比如说我向服务器提交数据的media type是xml的，而服务器只支持json，那么就会返回415
        /// </summary>
        [StatusCode(415, "不支持的mediaType")]
        UnsupportedMediaType,
        /// <summary>
        /// 422 - Unprocessable entity，表示请求的格式没问题，但是语义有错误，例如实体验证错误。
        /// </summary>
        [StatusCode(422,"语法错无的请求格式")]
        UnprocessableEntity,
        /// <summary>
        /// 500 - Internal server error，这表示是服务器发生了错误
        /// </summary>
        [StatusCode(500,"服务器内部故障")]
        InternalServerError
    }
}
