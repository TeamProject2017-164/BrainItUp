
select 
u.UserId, 
u.NickName, 
Correct = Sum(cast(IsCorrect as Int)), 
Total = Sum(1) , 
Ratio = 100 *  Sum(cast(IsCorrect as Int)) / Sum(1)  
from UserAnswers ua
inner join Users u on u.UserId = ua.UserId
inner join Answers a on a.AnswerId = ua.AnswerId
group by u.UserId, u.NickName
order by 4 desc