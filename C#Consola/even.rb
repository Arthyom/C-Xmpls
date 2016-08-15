a = gets.to_i
arr = Array.new(a){|i| i = gets.to_i }
arr.each do |n|
    if(n.even?)
        puts 'true'
    else
        puts'false'
    end
end